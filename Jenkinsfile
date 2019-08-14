pipeline 
{
    agent any
    parameters 
	{
        string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-vkumar/WebApi.git', description: 'repository path')
        string(name: 'SOLUTION_PATH', defaultValue: 'WebApi.sln', description: 'solution path')
        string(name: 'TEST_PATH', defaultValue: 'WebAPI.Test/WebAPI.Test.csproj', description: 'test path')
	choice(name: 'JOB', choices: ['Build', 'Test'], description: 'Providing Choices' )
    	}
    stages 
	{
        stage('Build') 
		{
            	steps 
		{
                	sh 'dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json'
                	sh 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n'
            	}
        	}
        stage('Test') 
	{
		when 
		{ 
			expression { params.JOB == 'Test'}
		}
            steps 
		{
			sh 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n'
                	sh 'dotnet test ${TEST_PATH}'
            	}
        }
    }
}