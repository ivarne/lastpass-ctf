#docker login bouvetctf.azurecr.io
#docker run -it --rm -p 5000:80 --name bouvet-ctf_sample bouvet-ctf
docker build -t bouvet-ctf .
docker tag bouvet-ctf bouvetctf.azurecr.io/bouvet-ctf
docker push bouvetctf.azurecr.io/bouvet-ctf