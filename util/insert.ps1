# Set the base URL of your API
$baseUrl = "http://localhost:5116/api"

# Function to make a GET request to retrieve data from the API
function Get-Data {
    param (
        [string]$endpoint
    )

    $url = "$baseUrl/$endpoint"
    
    try {
        $response = Invoke-RestMethod -Uri $url -Method Get
        
        # Print the response
        $response
    }
    catch {
        Write-Host "Error occurred while making the GET request:`n$($_.Exception.Message)"
    }
}

# Function to make a POST request to insert data into the API
function Insert-Data {
    param (
        [string]$endpoint,
        [string]$jsonPayload
    )

    $url = "$baseUrl/$endpoint"
    Write-Output $url
    try {
        $response = Invoke-RestMethod -Uri $url -Method Post -ContentType "application/json" -Body $jsonPayload
        
        # Print the response
        $response
    }
    catch {
        Write-Host "Error occurred while making the POST request:`n$($_.Exception.Message)"
    }
}



# Create a sample JSON payload
$jsonData = @"
{   
     "clientName": "test2343",
    "dataType": "DataType23",
    "jsonData": "{\"Name\": \"Test\", \"Age\": 30  }"
}
"@

# Make a POST request to insert data
Insert-Data -endpoint "ClientData" -jsonPayload $jsonData

# Make a GET request to retrieve data
Get-Data -endpoint "clientdata?clientName=test2343"
