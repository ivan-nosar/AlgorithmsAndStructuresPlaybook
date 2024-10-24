# Configuring test output directory
$testRevisionId = New-Guid
$testResultsDirectory = "./TestResults/$($testRevisionId)"

# Run tests
Write-Host "Writing test results to $($testResultsDirectory)"
dotnet test --results-directory $testResultsDirectory --collect:"XPlat Code Coverage" -v quiet

# Build a human-readable report
$testReportFolder = "coverage-report"
Write-Host "Tests finished. Building coverage report..."
reportgenerator -reports:"$($testResultsDirectory)\**\coverage.cobertura.xml" -targetdir:$testReportFolder -reporttypes:Html | Out-Null

$fullCoverageReportPath = Join-Path $(Get-Location) $testReportFolder "index.html"
Write-Host "Coverage report can be accessd at $($fullCoverageReportPath)"