#!/bin/bash
sudo apt-get update

echo =======================================================
echo Installing required dependencies
echo =======================================================

wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-3.1
sudo apt-get install -y jq libsnappy-dev libc6-dev libc6 moreutils

echo =======================================================
echo Cloning repository & setting up scripts and folders
echo =======================================================

git clone https://github.com/NethermindEth/nethermind.git --recursive
cp nethermind/scripts/pullandbuild.sh ~
cp nethermind/scripts/infra.sh ~
mkdir src
mv nethermind/ src/
chmod +x pullandbuild.sh infra.sh
./pullandbuild.sh

echo =======================================================
echo Running Nethermind
echo =======================================================

read -e -p "Which configuration you wish to run? " -i "mainnet" config
cp nethermind/configs/$config.cfg ~
./infra.sh $config