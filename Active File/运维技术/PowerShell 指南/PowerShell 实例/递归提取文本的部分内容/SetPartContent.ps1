$path = Read-Host "Input the path to modify"


function Set-TextContent{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory,
        ValueFromPipeline)]
        [string]$path
    )

    begin {
        if(Test-Path $path) {
            Write-Output "Path do not exist!"
            break
        }
    }

    process {
        $content = Get-Content -Path $path -TotalCount 1500
        Clear-Content $path
        Set-Content -Path $path -Value $content

        Write-Output "Set content successful: $path"
    }
}

Get-ChildItem -Path $path -File -Recurse | Set-TextContent 