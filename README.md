# Instruccions instal·lació - Linux (Debian 11)

Font: https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian#debian-11

wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

apt-get update && \
  apt-get install -y dotnet-sdk-7.0

Creació app: https://learn.microsoft.com/en-us/dotnet/standard/get-started#tutorials-for-creating-apps

# VideoComposition
