
# to run 
sudo docker run --name postgres1 -p 5432:5432 -v /tmp/pgdata:/var/lib/postgresql/data -e POSTGRES_PASSWORD=yourpassword -d postgres

#list images
docker images

#list running containers
docker ps



#run admin
docker pull dpage/pgadmin4
docker run -p 81:80 --link fervent_fermat:fervent_fermat -e "PGADMIN_DEFAULT_EMAIL=user@domain.com" -e "PGADMIN_DEFAULT_PASSWORD=SuperSecret" -d dpage/pgadmin4