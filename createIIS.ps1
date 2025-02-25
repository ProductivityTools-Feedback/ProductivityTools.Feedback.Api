$exists = (&$appcmd list apppool /name:'PTFeedback') -ne $null
if ($exists -eq $false)
{
     appcmd add site /name:PTFeedback /bindings:http://*:8001 /physicalpath:"C:\\Bin\\IIS\\PTFeedback"
}