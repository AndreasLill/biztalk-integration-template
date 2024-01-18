$oldName = "BizTalk.IntegrationTemplate"
$newName = Read-Host "Enter the new name for the solution"

# Get all folders in root.
$folders = Get-ChildItem -Path $PSScriptRoot -Directory -Recurse

foreach ($folder in $folders) {
	
	# Check if folder contains template name.
	if ($folder.Name -match $oldName) {
		
		# Rename folder.
		$newFolderName = $folder.Name -replace $oldName, $newName
		Rename-Item -Path $folder.FullName -NewName $newFolderName
		
		Write-Host "Renamed folder " -NoNewline
		Write-Host $folder.Name -ForegroundColor Yellow
	}
}

# Get all files in root, excluding some extensions.
$files = Get-ChildItem -Path $PSScriptRoot -File -Recurse |
	Where-Object {
		$_.Extension -notin @(
			'.ps1',
			'.snk'
		)
	}

foreach ($file in $files) {
	
	# Read contents of file.
	$content = Get-Content $file.FullName
	
	# Replace template placeholder with new name in file.
	$newContent = $content -replace $oldName, $newName
	
	# Write new contents to file.
	Set-Content -Path $file.Fullname -Value $newContent
	
	if ($file.Name -match $oldName) {
		# Rename file.
		$newFileName = $file.Name -replace $oldName, $newName
		Rename-Item -Path $file.FullName -NewName $newFileName
		
		Write-Host "Renamed file " -NoNewline
		Write-Host $file.Name -ForegroundColor Yellow
	}
}