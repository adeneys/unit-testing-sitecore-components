# Unit Testing Sitecore Components Sample Code #

This repository contains sample code showing how to refactor Sitecore components for reusability, better design and testability.

The commits show the progressive refactorings made to the components and adding the tests. Each significant commit has been tagged.

## How to Build ##

### Files ###

The code uses references from NuGet, so should build without issue.

The solution can be configured to automatically deploy to a local Sitecore instance upon build. To enable automatic deployment, copy and rename the `deploy.props.sample` file to `deploy.props`. Open the new `deploy.props` file and set the inner text of the `/Project/PropertyGroup/DeployPath` element to the path of your local Sitecore instance such as:

	<Project>
	  <PropertyGroup>
		<DeployPath>C:\inetpub\wwwroot\sc930.sc</DeployPath>
	  </PropertyGroup>
	</Project>

Reload the solution so the properties are loaded. Now the files will deploy to Sitecore upon a successful build.

### Items ###

The solution uses [Unicorn](https://github.com/SitecoreUnicorn/Unicorn) to serialize items, and the serialized items must be synchronized into Sitecore upon first build. After building the solution, navigate to the `/unicorn.aspx` page of your Sitecore instance and click the `sync` button.

Once items have been deserialized, perform a publish.
