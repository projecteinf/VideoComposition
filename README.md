# Instruccions instal·lació - Linux (Debian 11)

Font: https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian#debian-11

wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

apt-get update && \
  apt-get install -y dotnet-sdk-7.0

# Creació aplicació
Font: https://learn.microsoft.com/en-us/dotnet/standard/get-started#tutorials-for-creating-apps

dotnet new console --framework net7.0   # Aplicació de consola

# Creació .gitignore

![image](https://github.com/projecteinf/VideoComposition/assets/96139692/8b82e9fc-ccda-42be-b914-b55f8b6f18da)

# Execució programa

![image](https://github.com/projecteinf/VideoComposition/assets/96139692/264b7074-ff05-4ee1-bd5d-25746cbd0f37)


# VideoComposition
