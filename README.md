# Spring PetClinic Sample Application In .Net Core Microservice and Angular 6
# Git
#petclinic
# DB steps 
1. create cloud sql instacnce
2. create db and procedures with scripts present at Awesome/petclinicbackend/database/mysqlscripts/
3. give the password to root same is going to be use in appsetting.json  

# Steps to run the microservice on GKE
  1. create my sql server on cloud sql 
  2. To connect the application pod to my sql we need to use sql proxy 
      more details about proxy is on 
      https://cloud.google.com/sql/docs/mysql/sql-proxy
  3. We are going to create 2 containers in a pod one for sql proxy and other for microservice application 
  4. We need to create the service account whihc will have roles of sql admin, sql client and sql editor
  5. Generate the private key say key.json for the service account and save it at some  place. 
  6. Private key will be used by sql proxy to authorize connection to cloud sql
  7. Change the connection setting in appsetting.json i.e database name, server ip will be 127.0.0.1 as it is through ip sql proxy and port          will be 3307/3306
  8. Below commands to be used 
      i.  export PROJECT_ID=$(gcloud config get-value core/project)---set project id
      ii. docker build -t gcr.io/${PROJECT_ID}/petclinicrestservice:v1 . ---docker file present at              
          Awesome/petclinicbackend/customerservice/
      iii. docker push gcr.io/${PROJECT_ID}/petclinicrestservice:v1
      iv. create secret key from private key file of service account
          a. kubectl create secret generic credentials --from-file=<path to json file>(i.e /home/g86mehtamohit/mysqlacesskey.json)
      v.  create cluster -- gcloud container clusters create petclinic-restservice --zone us-central1-a
      vi. update the Instance connection name of cloudsql instance in deployment_final.yaml at line 21 in command
      vii.  kubectl apply -f deployment.yaml(attached deployment.yaml)   
      viii. kubectl expose deployment petclinic-restservice --type="LoadBalancer" --port=80
  9 browse http://<external ip>/petclinic/api/owners
  
  # Steps to run petclinic frontend
      Edit environment.ts file in (\Awesome\petclinicfrontend\src\app\owners) and update url for rest service http://<external ip>/petclinic/api generated above
      1.  export PROJECT_ID=$(gcloud config get-value core/project)---set project id
      2. docker build -t gcr.io/${PROJECT_ID}/petclinicfrontend:v1 .
      3. docker push gcr.io/${PROJECT_ID}/petclinicfrontend:v1
      4. create cluster gcloud container clusters create petclinic-app --zone us-central1-a
      5. kubectl apply -f deployment_frontend.yaml(attached deployment_frontend.yaml)  
      6. kubectl expose deployment petclinic-app --type="LoadBalancer" --port=80
      7. Browse the usrl with the external ip generated
      
   # Steps to setup CI/CD through google respository and cloud build triggers
     1. set up new repository in cloud repsitory
     2. create trigger for cloud build using cloudbuild.yaml file
     3. Follow manual steps mentioned in attached manaul steps documents before triggering the build
  
