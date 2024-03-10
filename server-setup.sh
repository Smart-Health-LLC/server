# ------- new user to work within OS safely
adduser <User>
passwd <User>
# ubuntu
usermod -aG sudo User
# cent os
gpasswd -a <User> wheel
yum install sudo

su - <User>


# ----- Add ssh key
mkdir .ssh
chmod 700 .ssh
vi .ssh/authorized_keys

# ------- firewall
sudo yum update
sudo yum install firewalld -y
sudo systemctl enable firewalld
sudo systemctl start firewalld
# don't forget to add ports and apps firewall exceptions
# btw don't forget to set up port forwarding


# ----- Configure timezones
sudo timedatectl set-timezone Asia/Irkutsk
sudo timedatectl

# ----- Configure NTP Synchronization
sudo yum install ntp -y
sudo systemctl start ntpd
sudo systemctl enable ntpd

# ----- Create a Swap File
sudo fallocate -l 4G /swapfile
sudo chmod 600 /swapfile
sudo mkswap /swapfile
sudo swapon /swapfile
sudo sh -c 'echo "/swapfile none swap sw 0 0" >> /etc/fstab'


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

# ---- Install dotnet
sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
sudo yum install dotnet-sdk-7.0 -y
sudo yum install dotnet-runtime-7.0 -y


# ---- Install postgres
sudo yum install postgresql -y
sudo yum install postgresql-server -y


# --- create postgres cluster
sudo postgresql-setup initdb

# ---- setup postgres service
sudo systemctl start postgresql
sudo systemctl enable postgresql

# verify
sudo -u postgres psql -c "SELECT version();"
