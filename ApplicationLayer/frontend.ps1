param( [Parameter(Mandatory=$true)] $command)

If ($command -eq "build:dev") {
    docker run -it --rm --name dotnet-frontend -v ${PWD}:/usr/src/app -w /usr/src/app node:lts npm run dev
}

If ($command -eq "build:prod") {
    docker run -it --rm --name dotnet-frontend -v ${PWD}:/usr/src/app -w /usr/src/app node:lts npm run prod
}