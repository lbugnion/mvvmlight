Add-Type -Assembly System.IO.Compression.FileSystem

$directories = Get-Childitem . -Directory
$compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal

foreach ($d in $directories)
{
    Write-Host $d.FullName
	
	$zipfilename = $d.FullName + ".zip"
   
    [System.IO.Compression.ZipFile]::CreateFromDirectory(
        $d.FullName,
        $zipfilename, 
		$compressionLevel, 
		$false)
}
