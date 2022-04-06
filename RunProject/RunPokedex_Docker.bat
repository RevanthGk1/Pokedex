@echo on
cd ../Pokedex
docker build -t pokedex:v1 .
docker run -it --rm -p 5000:80 pokedex:v1
#docker run -dp 5000:80 pokedex:v1