docker rmi ayo-runner/flyway 
docker build -f migrate.dockerfile --force-rm -t ayo-runner/flyway .
docker run --rm -it --network=host -e HOST=localhost -e DB=postgres -e USER=root  ayo-runner/flyway /bin/bash -c migrate.sh