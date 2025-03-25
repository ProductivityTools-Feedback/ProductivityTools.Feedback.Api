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

        stage('create iis page') {
            steps {
                powershell('''
                function CheckIfExist($Name){
                    cd $env:SystemRoot\\system32\\inetsrv
                    $exists = (.\\appcmd.exe list sites /name:$Name) -ne $null
                    Write-Host $exists
                    return  $exists
                }
                
                function Create($Name,$HttpbBnding,$PhysicalPath){
                    $exists=CheckIfExist $Name
                    if ($exists){
                        write-host "Web page already existing"
                    }
                    else
                    {
                        write-host "Creating webage"
                        .\\appcmd.exe add site /name:$Name /bindings:http://$HttpbBnding /physicalpath:$PhysicalPath
                    }
                }
                Create "PTFeedback" "*:8001"  "C:\\Bin\\IIS\\PTFeedback\\"                
                ''')
            }
        }

        stage('just hello') {
            steps {
                powershell('write-host "aweol"')
            }
        }

        stage('stopSiteOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:PTFeedback')
            }
        }

        stage('listSite') {
            steps {
                  echo 'listing sites so remvoe will succeed'
            }
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd list sites')
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
                echo 'bye bye bye'
            }
        }
    }
}
