properties([pipelineTriggers([githubPush()])])

pipeline {
    agent any

    stages {
        stage('hello') {
            steps {
                // Get some code from a GitHub repository
                echo 'hello'
            }
        }
        stage('deleteWorkspace') {
            steps {
                deleteDir()
            }
        }

        stage('clone') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'master',
                url: 'https://github.com/ProductivityTools-TeamManagement/ProductivityTools.TeamManagement.Api'
            }
        }
        stage('build') {
            steps {
                bat(script: "dotnet publish ProductivityTools.TeamManagement.Api.sln -c Release ", returnStdout: true)
            }
        }
        stage('deleteDbMigratorDir') {
            steps {
                bat('if exist "C:\\Bin\\TeamManagementDdbMigration" RMDIR /Q/S "C:\\Bin\\TeamManagementDdbMigration"')
            }
        }
        stage('copyDbMigratorFiles') {
            steps {
                bat('xcopy "c:\\ProgramData\\Jenkins\\.jenkins\\workspace\\TeamManagement\\ProductivityTools.TeamManagement.Api.DatabaseMigrations\\bin\\Release\\netcoreapp3.1\\publish\\" "C:\\Bin\\TeamManagementDdbMigration\\" /O /X /E /H /K')
            }
        }

        stage('runDbMigratorFiles') {
            steps {
                bat('C:\\Bin\\TeamManagementDdbMigration\\ProductivityTools.TeamManagement.Api.DatabaseMigrations.exe')
            }
        }

        stage('stopSiteOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:teammanagement')
            }
        }

        stage('deleteIisDir') {
            steps {
                retry(5) {
                    bat('if exist "C:\\Bin\\TeamManagement" RMDIR /Q/S "C:\\Bin\\TeamManagement"')
                }

            }
        }
        stage('copyIisFiles') {
            steps {
                bat('xcopy "c:\\Program Files (x86)\\Jenkins\\workspace\\TeamManagement\\ProductivityTools.TeamManagement.Api\\bin\\Release\\net6.0\\publish\\" "C:\\Bin\\TeamManagement\\" /O /X /E /H /K')
				                      
            }
        }

        stage('startSiteOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:teammanagement')
            }
        }
        stage('byebye') {
            steps {
                // Get some code from a GitHub repository
                echo 'bye'
            }
        }
    }
}
