FROM microsoft/dotnet:2.0-sdk as build

# Inject the Opux source into the image
COPY src/Opux /build

# Set the current working directory
WORKDIR /build

# Build Opux
#RUN dotnet restore
#RUN dotnet build
RUN dotnet publish --output ./out --configuration Debug --framework netcoreapp2.0


FROM microsoft/dotnet:2.0-runtime

LABEL maintainer="guy.pascarella@gmail.com"

# Set the current working directory
WORKDIR /app

# Copy from the first image into here
COPY --from=build /build/out .

# Note: The run command of dotnet is the more official version of the exec command
#CMD ["dotnet", "run"]
#CMD ["dotnet", "exec", "/app/bin/Debug/netcoreapp2.0/Opux.dll"]
CMD ["dotnet", "exec", "/app/Opux.dll"]
