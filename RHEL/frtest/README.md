# An example of using FastReport .NET in a RHEL8/.NET6 container

This example contains code for a simple MVC application with [FastReport .NET](https://www.fast-report.com/en/product/fast-report-net/) for .NET 6 and the Dockerfile needed to build a container image for use in [Red Hat Enterprise Linux](https://www.redhat.com/en/technologies/linux-platforms/enterprise-linux).

## Build

```
podman build -f Dockerfile -t frdemo
```

Please pay attention to the following points:
- the project file frtest.csproj contains a link to system.drawing.common version 5.0.2 - this is necessary for correct rendering of text in bitmaps, if this reference is missing you will see some squares instead of letters or any strange symbols;
- when building an image, the libgdiplus library is compiled, which requires several dependencies;
- for the correct work of the reports, which were created in the Windows operating system, MS fonts are installed and registered in the image, pay attention to the legal aspects before using this solution or just remove the related lines in the Dockerfile;
- some dependencies require an [EPEL](https://docs.fedoraproject.org/en-US/epel/) repository;
- the base `ubi8/dotnet-60-runtime` image is used to reduce the size of the resulting image; 
- further size optimization is possible by moving the libgdiplus assembly to another stage.

## Run

```
podman run -p 8080:8080 frdemo
```

Open the application in your browser

```
https://localhost:8080
```

The container has been tested under Red Hat Enterprise Linux 8.5.

## References

[.NET 6 SDK and Runtime images for Red Hat](https://catalog.redhat.com/software/containers/search?q=.NET%206.0%20SDK%20and%20Runtime&p=1)

[.NET 6.0 Runtime Only images for Red Hat](https://catalog.redhat.com/software/containers/search?q=.NET%206.0%20Runtime%20Only&p=1)

[Red Hat Container Registry Authentication](https://access.redhat.com/RegistryAuthentication)

[Extra Packages for Enterprise Linux (EPEL)](https://docs.fedoraproject.org/en-US/epel/#Quickstart)