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
                bat('if exist "C:\\Bin\\FeedbackDdbMigration" RMDIR /Q/S "C:\\Bin\\FeedbackDdbMigration"')
            }
        }
        stage('copyDbMigratorFiles') {
            steps {
                bat('xcopy "PTFeedback.Api\\ProductivityTools.Feedback.Api.DatabaseMigrations\\bin\\Release\\net6.0\\publish\\" "C:\\Bin\\DbMigration\\Feedback.Api\\" /O /X /E /H /K')
            }
        }

        stage('runDbMigratorFiles') {
            steps {
                bat('C:\\Bin\\DbMigration\\Feedback.Api\\ProductivityTools.Feedback.Api.DatabaseMigrations.exe')
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
                bat('xcopy "PTFeedback.Api\\ProductivityTools.Feedback.Api\\bin\\Release\\net6.0\\publish\\" "C:\\Bin\\IIS\\PTFeedback\\" /O /X /E /H /K')
				                      
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
