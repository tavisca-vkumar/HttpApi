pipeline {
     agent any
     
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'HttpApi.sln')
 
     string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
     string(name: 'GIT_REPO_PATH', defaultValue: 'https://github.com/tavisca-vkumar/HttpApi.git')
     string(name:'IMAGE_NAME',defaultValue:'vikeshsample-image',description: 'Enter the image name')
      string(name: 'DOCKER_LOGIN',defaultValue:'vikesh5329', description: 'Enter Login')
       password(name: 'DOCKER_PASSWORD', defaultValue:'Vikesh@123', description: 'Enter Password')
       string(name: 'TAG_NAME', defaultValue: 'version', description: 'enter tag name')
         string(name:"DOCKER_REPO_NAME",defaultValue:"HttpApi")
         string(name: 'DOCKER_CONTAINER_NAME',defaultValue: 'simpleApi')
              
	string(name: 'SOLUTION_DLL_FILE',defaultValue: './HttpApi/HttpApi/bin/Debug/netcoreapp2.1/HttpApi.dll')

   
     choice(name: 'JOB', choices:  ['Build', 'Deploy'])
    }
    
    
   
       stages
       {
        
          stage('Build') 
          {
            
               steps 
	       {
              
		 when{expression{params.JOB == "Build"}}
                 powershell(script: 'dotnet build ${env:APPLICATION_PATH} -p:Configuration=release -v:n')
                 powershell(script: 'dotnet test')
                 powershell(script: 'dotnet publish') 
               }
          }
                
     stage('Docker Creation')
        {
             steps{
           powershell(script:'docker build -t ${env:IMAGE_NAME} .')
           powershell(script:'docker login -u ${env:DOCKER_LOGIN} -p ${env:DOCKER_PASSWORD}')
           powershell(script:'docker tag ${env:IMAGE_NAME}:latest ${env:DOCKER_LOGIN}/${env:DOCKER_REPO_NAME}:${env:TAG_NAME}')
             }           
             }
        stage(' Docker Image Pushing')
        {
            steps 
            {
              
                powershell(script:'docker push ${env:DOCKER_LOGIN}/${env:DOCKER_REPO_NAME}:${env:TAG_NAME}')
            }
        }
            
           
    }
    
}