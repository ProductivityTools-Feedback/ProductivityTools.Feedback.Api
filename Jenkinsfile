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
        
        stage('just hello') {
            steps {
                powershell('write-host "aweol"')
            }
        }

        stage('deleteWorkspace') {
            steps {
                deleteDir()
            }
        }

        stage('Git clone') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'main',
                url: 'https://github.com/ProductivityTools-Feedback/ProductivityTools.Feedback.Api.git'
            }
        }
        stage('Build solution') {
            steps {
                bat(script: "dotnet publish ProductivityTools.Feedback.Api.sln -c Release ", returnStdout: true)
            }
        }
        stage('Delete databse migration directory') {
            steps {
                bat('if exist "C:\\Bin\\DbMigration\\Feedback.Api" RMDIR /Q/S "C:\\Bin\\DbMigration\\Feedback.Api"')
            }
        }
        stage('Copy database migration files') {
            steps {
                bat('xcopy "ProductivityTools.Feedback.Api.DatabaseMigrations\\bin\\Release\\net9.0\\publish\\" "C:\\Bin\\DbMigration\\Feedback.Api\\" /O /X /E /H /K')
            }
        }

        stage('Run databse migration files') {
            steps {
                bat('C:\\Bin\\DbMigration\\Feedback.Api\\ProductivityTools.Feedback.Api.DatabaseMigrations.exe')
            }
        }

        stage('Create page on the IIS') {
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
                        write-host "Creating app pool"
                        .\\appcmd.exe add apppool /name:$Name /managedRuntimeVersion:"v4.0" /managedPipelineMode:"Integrated"
                        write-host "Creating webage"
                        .\\appcmd.exe add site /name:$Name /bindings:http://$HttpbBnding /physicalpath:$PhysicalPath
                        write-host "assign app pool to the website"
                        .\\appcmd.exe set app "$Name/" /applicationPool:"$Name"


                    }
                }
                Create "PTFeedback" "*:8001"  "C:\\Bin\\IIS\\PTFeedback\\"                
                ''')
            }
        }



        stage('Stop page on the IIS') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:PTFeedback')
            }
        }

		stage('Delete PTFeedback IIS directory') {
            steps {
              powershell('''
                if ( Test-Path "C:\\Bin\\IIS\\PTFeedback")
                {
                    while($true) {
                        if ( (Remove-Item "C:\\Bin\\IIS\\PTFeedback" -Recurse *>&1) -ne $null)
                        {  
                            write-output "removing failed we should wait"
                        }
                        else 
                        {
                            break 
                        } 
                    }
                  }
              ''')

            }
        }
        stage('Copy web page to the IIS Bin directory') {
            steps {
                bat('xcopy "ProductivityTools.Feedback.Api\\bin\\Release\\net9.0\\publish\\" "C:\\Bin\\IIS\\PTFeedback\\" /O /X /E /H /K')
				                      
            }
        }

        stage('startSiteOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:PTFeedback')
            }
        }
        stage('Create Login PTFeedback on SQL2022') {
             steps {
                 bat('sqlcmd -S ".\\SQL2022" -q "CREATE LOGIN [IIS APPPOOL\\PTFeedback] FROM WINDOWS;"')
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
