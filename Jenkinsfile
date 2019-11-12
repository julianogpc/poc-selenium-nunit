pipeline {
    agent {
      label 'master'
    }

    environment {
        DOCKER_HOST = "tcp://192.168.0.131:2375"
        TRX_FILE = "TestResults.trx"
        JENKINS_CONTAINER_NAME = sh (
            script: 'DOCKER_HOST=tcp://192.168.0.131:2375 docker ps --filter=name=jenkins --format="{{.Names}}" | tail -1',
            returnStdout: true
        ).trim()
    }
    
    stages {
        stage('Initialize') {
            steps {
                script {
                    properties([[$class: 'JiraProjectProperty'], buildDiscarder(logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '', daysToKeepStr: '30', numToKeepStr: '15')), disableConcurrentBuilds(), disableResume(), pipelineTriggers([pollSCM('H/2 * * * *')])])
                }
                git branch: 'master', credentialsId: 'GIT_USER', url: 'http://192.168.0.131:10080/jcosta/poc-selenium-nunit.git'
            }
        }
        stage('Build') { 
            agent {
              docker {
                args '''
                    -u root
                    --volumes-from=${JENKINS_CONTAINER_NAME}
                    '''
                image 'mcr.microsoft.com/dotnet/core/sdk:3.0'
                reuseNode true
              }
            }
            steps {
                sh '''
                    dotnet build
                '''
            }
        }
        stage('Test') { 
            agent {
              docker {
                args '''
                    -u root
                    --volumes-from=${JENKINS_CONTAINER_NAME}
                    '''
                image 'mcr.microsoft.com/dotnet/core/sdk:3.0'
                reuseNode true
              }
            }
            steps {
                catchError(buildResult: 'UNSTABLE', stageResult: 'UNSTABLE') {
                    sh '''
                        dotnet test --logger="trx;LogFileName=${TRX_FILE}"
                    '''
                }
                sh '''
                    chown -R 1000:1000 .
                '''
            }
        }
        stage('Publish') { 
            steps {
                allure includeProperties: false, jdk: '', results: [[path: 'Selenium.Tests/bin/Debug/netcoreapp3.0/allure-results']]
                mstest failOnError: false, testResultsFile: '**/TestResults.trx'
            }
        }
    }
    
    post {
        always {
            cleanWs()
        }
    }
}