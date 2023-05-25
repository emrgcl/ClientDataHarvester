# ClientDataHarvester

# Build and Publish for IIS


1. **Build the application:** Open a command prompt or terminal and navigate to the root directory of your ASP.NET Core application. Run the following command to build the application:

    ```PowerShell
    dotnet build --configuration Release
    ```

1. **Publish the application:** Run the following command to publish the application: 
    ```PowerShell
    dotnet publish --configuration Release --output <publish-folder>
    ```

    Replace `<publish-folder>` with the desired folder path where you want to publish the application files. For example, C:\Publish.1


# update packages offline.

1. Obtain the NuGet packages: On a machine with internet access, use the following command in the terminal to download the NuGet packages and their dependencies:

    ```PowerShell
    dotnet restore --packages <path-to-packages-folder>
    ```

    Replace **`<path-to-packages-folder>`** with the desired folder path where you want to store the downloaded NuGet packages. For example, **`C:\NuGetPackages.`**

    This command will restore the packages and save them to the specified folder.

1. **Transfer the packages:** Once the packages are downloaded, transfer the entire contents of the **`<path-to-packages-folder>`** to the server without internet access. You can use methods like copying the files to a USB drive or using a secure file transfer method.

1. **Configure local package source:** On the server without internet access, open the NuGet configuration file **(`NuGet.config`)** in a text editor. This file is typically located in the solution or project directory. Solution root is better.

    ```xml
    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
    <packageSources>
    <!-- Other package sources if any -->
    <add key="Local Packages" value="D:\ClientDataHarvester\Packages" />
    </packageSources>
    </configuration>
    ```

1. **Update Project (.csproj):** Replace **`<path-to-packages-folder>`** with the actual path where you transferred the NuGet packages on the server. For example, C:\NuGetPackages.

    ```xml
    <ItemGroup>
    <PackageReference Include="YourPackageName" Version="x.x.x" />
    <!-- Other package references if any -->
    </ItemGroup>
    <ItemGroup>
    <PackageSources Include="<path-to-packages-folder>" />
    </ItemGroup>

    ```

    Again, replace **`<path-to-packages-folder>`** with the actual path where you transferred the NuGet packages on the server.

1. **Restore packages:** In the root directory of your project, run the following command to restore the packages from the local package source:

    ```PowerShell
    dotnet restore
    ```

By following these steps, you should be able to manually install and reference NuGet packages on a server without internet access. Remember to repeat the process whenever you need to update or add new packages to the server.

## Create Database Migrations.

1. Make sure you have Entity Framework Core tools installed globally. You can install it by running the following command in the terminal:

    ```PowerShell
    dotnet tool install --global dotnet-ef
    ```

2. Ensure that your current working directory is the root of your project (where the .csproj file is located).

3. Run the following command to add a new migration:

    ```PowerShell
    dotnet ef migrations add InitialCreate

    ```
    This command will generate a new migration file in the Data/Migrations directory with the name InitialCreate (or any other name you choose).


4. Finally, apply the migration to create the tables in the database by running the following command:
    ```PowerShell
    dotnet ef database update

    ```

## Create sql schema
once the app is ready runt he following to create a db schema sql 

```PowerShell
dotnet ef migrations script --output <output-file.sql> --context ClientDataContext
```
