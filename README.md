# Keystone.Net
.Net Core Client to Access Open Stack Keystone

# Build Docker Image of Keystone
```
cd docker
docker build -t keystone:v3 .
```

# Install Keystone
a. Install mariadb (via docker)  
```
docker run --name mariadb -e MYSQL_ROOT_PASSWORD={password} -p 3306:3306 -d mariadb:10.4 --character-set-server=utf8mb4 --collation-server=utf8mb4_unicode_ci
```

Please replace the {password} with your own password, use 'root' here.

b. Install memcached (via docker)  
```
docker run --name memcache -d -p 11211:11211 memcached:1.6-alpine
```

c. Prepare config  
`
vi /etc/keystone/keystone.conf
`
```
[DEFAULT]
max_project_tree_depth = 10

[oslo_middleware]
enable_proxy_headers_parsing = True

[database]
connection = mysql+pymysql://{username}:{password}@{your id}:3306/keystone
max_retries = -1

[token]
revoke_by_id = False
provider = fernet
expiration = 86400

[fernet_tokens]
max_active_keys = 4

[cache]
backend = oslo_cache.memcache_pool
enabled = True
memcache_servers = {your id}:11211
```

Please replace {username}, {password}, {your id} with your own.

Start keystone  
```
mkdir -p /var/log/keystone
mkdir -p /var/log/httpd
docker run --name keystone -d -v /etc/keystone/keystone.conf:/etc/keystone/keystone.conf -v /var/log/keystone:/var/log/keystone -v  /var/log/httpd:/var/log/httpd -p 5000:5000 keystone:v3
```

Init database  
Create a database named keystone, and execute the following scripts:  
```
docker exec -it keystone bash
chown keystone.keystone /var/log/keystone/keystone.log
su -s /bin/sh -c "keystone-manage db_sync" keystone
```

Register service  
```
docker exec -it keystone bash
keystone-manage bootstrap --bootstrap-password {password} --bootstrap-admin-url http://{your id}:5000/v3/ --bootstrap-internal-url http://{your id}:5000/v3/ --bootstrap-public-url http://{your id}:5000/v3/ --bootstrap-region-id {region id}
```

Please replace {password}, {your id}, {region id} with your own.
