# Docker notater

# I hovedsak er det følgende komando som skal kjøres
docker build -t bouvet-ctf . && docker run -it --rm -p 5000:80 --name bouvet-ctf_sample bouvet-ctf

# For deploy trengs også følgende
#docker login bouvetctf.azurecr.io
#docker build -t bouvet-ctf .
#docker tag bouvet-ctf bouvetctf.azurecr.io/bouvet-ctf
#docker push bouvetctf.azurecr.io/bouvet-ctf
