# Use the official .NET 8 SDK image as a build and runtime environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Install dependencies for Chrome and Firefox
RUN apt-get update && apt-get install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg \
    --no-install-recommends

# Install Google Chrome
RUN curl -sSL https://dl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb [arch=amd64] http://dl.google.com/linux/chrome/wd/deb/ stable main" > /etc/apt/sources.list.d/google-chrome.list \
    && apt-get update && apt-get install -y \
    google-chrome-stable \
    --no-install-recommends

# Install Firefox
RUN apt-get install -y firefox-esr --no-install-recommends

# Set environment variables for Headless execution
ENV HEADLESS=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Set the working directory
WORKDIR /app

# Copy the project files and restore dependencies
COPY . .
RUN dotnet restore

# Build the project
RUN dotnet build --no-restore --configuration Release

# Define the entry point for running tests
ENTRYPOINT ["dotnet", "test", "--configuration", "Release", "--no-build", "--results-directory", "/app/TestResults", "--logger", "trx"]
