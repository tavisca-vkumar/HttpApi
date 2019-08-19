pipeline{
    agent any
    parameters{
        string(
            name: "GIT_PATH",
            defaultValue: "https://github.com/tavisca-vkumar/HttpApi.git",
            description: "git repo ki path hai ye"
        )
        string(
            name: "SOLUTION_PATH",
            defaultValue: "HttpApi.sln",
            description: "solution path hai ye"
        )
        string(
            name: "TEST_PATH",
            defaultValue: "HttpApi.Tests/HttpApi.Tests.csproj",
            description: "test solution path hai ye"
        )
        
        string(
            name: "PROJECT_PATH",
            defaultValue: "HttpApi/HttpApi.csproj",
        )
         string(
            name: "DOCKERFILE",
            defaultValue: "mcr.microsoft.com/dotnet/core/aspnet",
        )
         string(
            name: "ENV_NAME",
            defaultValue: "Api",
        )
         string(
            name: "SOLUTION_DLL_FILE",
            defaultValue: "HttpApi.dll",
        )
        string(
            name: "DOCKER_USERNAME",
            description: "Dockerhub USer name"
        )
        string(
            name: "DOCKER_PASSWORD",
            description:  "Docker hub Password"
        )
        choice(
            name: "OPTION",
            choices: ["Build", "Deploy"],
            description: "Choice"
        )
    }
    stages
    {
        stage('Build')
        {
            when{expression{params.OPTION == "Build"}}
            steps
            {
                sh '''
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json
                    dotnet build ${PPOJECT_PATH}
                    dotnet test ${TEST_PATH}
                    dotnet publish ${PROJECT_PATH}
                '''
                bat 'zip zipFile: 'publish.zip', archive: false, dir: 'HttpApi.Core/bin/Debug/netcoreapp2.2/publish'
                archiveArtifacts artifacts: 'publish.zip', fingerprint: true'
            }
        }
        stage('Deploy')
        {
        when{expression{params.OPTION == "Deploy"}}
            steps
            {
                writeFile file: 'HttpApi/bin/Debug/netcoreapp2.2/publish/Dockerfile', 
                text: '''
                        FROM mcr.microsoft.com/dotnet/core/aspnet\n
                        ENV NAME ${PROJECT_NAME}\n
                        CMD ["dotnet", "${SOLUTION_DLL_FILE}"]\n
                    '''
                
                sh "docker build HttpApi.Core/bin/Debug/netcoreapp2.2/publish/ --tag=${PROJECT_NAME}:${BUILD_NUMBER}"    
                sh "docker tag ${PROJECT_NAME}:${BUILD_NUMBER} ${DOCKER_USERNAME}/${PROJECT_NAME}:${BUILD_NUMBER}"
                sh "docker login -u ${DOCKER_USERNAME} -p ${DOCKER_PASSWORD}"
                sh "docker push ${DOCKER_USERNAME}/${PROJECT_NAME}:${BUILD_NUMBER}"
            }
        }
    }
    post
    {
        always
        {
            deleteDir()
        }
    }
}
