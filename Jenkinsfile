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
                git branch: 'main',
                url: 'https://github.com/ProductivityTools-Feedback/ProductivityTools.Feedback.Api.git'
            }
        }
        stage('build') {
            steps {
                bat(script: "dotnet publish ProductivityTools.Feedback.Api.sln -c Release ", returnStdout: true)
            }
        }
        stage('deleteDbMigratorDir') {
            steps {
                bat('if exist "C:\\Bin\\DbMigration\\Feedback.Api" RMDIR /Q/S "C:\\Bin\\DbMigration\\Feedback.Api"')
            }
        }
        stage('copyDbMigratorFiles') {
            steps {
                bat('xcopy "ProductivityTools.Feedback.Api.DatabaseMigrations\\bin\\Release\\net9.0\\publish\\" "C:\\Bin\\DbMigration\\Feedback.Api\\" /O /X /E /H /K')
            }
        }

        stage('runDbMigratorFiles') {
            steps {
                bat('C:\\Bin\\DbMigration\\Feedback.Api\\ProductivityTools.Feedback.Api.DatabaseMigrations.exe')
            }
        }

        stage('createIISPowershell'){
            node{
                powereshell '$exists = (&$appcmd list apppool /name:'PTFeedback') -ne $null
                if ($exists -eq $false)
                {
                    appcmd add site /name:PTFeedback /bindings:http://*:8001 /physicalpath:"C:\\Bin\\IIS\\PTFeedback"
                }'
            }
        }
        stage('createIIS') {
            steps {
                //bat('%windir%\\system32\\inetsrv\\appcmd add site /name:PTFeedback /bindings:http://*:8001 /physicalpath:"C:\\Bin\\IIS\\PTFeedback"')
            }
        }

        stage('stopSiteOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:PTFeedback')
            }
        }

        stage('deleteIisDir') {
            steps {
                retry(5) {
                    bat('if exist "C:\\Bin\\IIS\\PTFeedback" RMDIR /Q/S "C:\\Bin\\IIS\\PTFeedback"')
                }

            }
        }
        stage('copyIisFiles') {
            steps {
                bat('xcopy "ProductivityTools.Feedback.Api\\bin\\Release\\net9.0\\publish\\" "C:\\Bin\\IIS\\PTFeedback\\" /O /X /E /H /K')
				                      
            }
        }

        stage('startSiteOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:PTFeedback')
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
