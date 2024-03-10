# ------- new user to work within OS safely
adduser <User>
passwd <User>
usermod -aG sudo <User>

# ------- update
sudo apt update && sudo apt upgrade


# ------- Uncomplicated Firewall
sudo apt install ufw
sudo ufw allow OpenSSH
# verify
sudo ufw app list
sudo ufw enable
# verify
sudo ufw status
# add app or port permissions
# btw don't forget to set up port forwarding
sudo ufw allow <dotnet listening port> 
sudo ufw allow <server access port>



# ------- ssh key connection
cd ~
mkdir .ssh
cd .ssh
vim authorized_keys



# ----- Configure timezones
sudo timedatectl set-timezone Asia/Irkutsk
sudo timedatectl



# ---- No root user on SSH
sudo vi /etc/ssh/sshd_config 
# PermitRootLogin yes -> no
sudo systemctl reload sshd



# ---- no spamming attacks
sudo yum install fail2ban -y
sudo systemctl enable fail2ban

sudo vi /etc/fail2ban/jail.local

# [sshd]
# enabled   = true
# maxretry  = 6
# findtime  = 1h
# bantime   = 1d
# ignoreip  = 127.0.0.1/8 23.34.45.56

sudo systemctl start fail2ban



# ---- Install postgres
sudo apt install postgresql postgresql-contrib -y
sudo systemctl start postgresql.service


# ---- Install dotnet
# Get Ubuntu version
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update

sudo apt install dotnet-sdk-8.0 -y
sudo apt install dotnet-runtime-8.0 -y