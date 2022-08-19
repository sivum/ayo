docker build -f flyway.dockerfile --force-rm -t ayo/flyway .  
docker rmi $(docker images -f dangling=true -q --no-trunc)     