# Awesome
# Git
#petclinic
#Steps to run the microservice on GKE
  1. create my sql server on cloud sql 
  2. To connect the application pod to my sql we need to use sql proxy 
      more details about proxy is on 
      https://cloud.google.com/sql/docs/mysql/sql-proxy
  3. We are going to create 2 containers in a pod one for sql proxy and other for microservice application 
  4. We need to create the service account whihc will have roles of sql admin, sql client and sql editor
  5. Generate the private key say key.json for the service account and save it at some  place. 
  6. Private key will be used by sql proxy to authorize connection to cloud sql
  7. Change the connection setting in appsetting.json i.e database name, server ip will be 127.0.0.1 as it is through ip sql proxy and port          will be 3307/3306
  8. Below commands to be used Dockerfile is presemt in  
      i.  export PROJECT_ID=$(gcloud config get-value core/project)---set project id
      ii. docker build -t gcr.io/${PROJECT_ID}/petclinicrestservice:v1 .
      iii. docker push gcr.io/${PROJECT_ID}/petclinicrestservice:v1
      iv. create secret key from private key file of service account
          a. kubectl create secret generic credentials --from-file=<path to json file>(i.e /home/g86mehtamohit/mysqlacesskey.json)
      v.  kubectl apply -f deployment.yaml(attached deployment.yaml)   
      vi. kubectl expose deployment petclinic-restservice --type="LoadBalancer" --port=80
  
