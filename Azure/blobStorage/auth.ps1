param(
	[string]$appName = 'blob'
)

New-Item -ItemType File -Name 'azureauth.json' -Path C:\Users\$env:username
az ad sp create-for-rbac --name $appName --sdk-auth | Out-File "C:\Users\$env:username\azureauth.json"