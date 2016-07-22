if ($null -eq (Get-Module PSCompletion))
{
	Write-Debug "Import-Module PSCompletion -Global"
	Import-Module PSCompletion -Global -ErrorAction SilentlyContinue
	if ($null -eq (Get-Module PSCompletion))
	{
		Write-Warning "PSCompletion module not found; tab completion will be unavailable."
	}
}