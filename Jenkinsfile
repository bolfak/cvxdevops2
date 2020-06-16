pipeline {
  agent any
  environment {
    APP_VERSION = '${BUILD_NUMBER}'
    DOCKER_REGISTRY = 'bolfak'
    APP_NAME = 'myfirstwebapp'
    DEPLOYMENT_NAME = 'myapp-test-deployment'
    CONTAINER_NAME = 'myapp-test'
    dockerImage = ''
    REGISTRY_CREDENTIALS = 'DockerHub'
  }
  stages {
    stage('Restore Dependencies') {
      steps {
        sh 'dotnet restore'
      }
    }
    stage('Build') {
      steps {
        sh 'dotnet build'
      }
    }
    stage('Run Tests') {
      steps {
        sh 'dotnet test'
      }
    }
    stage('Build Docker Image') {
      steps {
        script {
          dockerImage = docker.build "${DOCKER_REGISTRY}/${APP_NAME}:${BUILD_NUMBER}"
        }
      }
    }
    stage('Push Docker Image to Registry') {
      steps {
        script {
          docker.withRegistry( '', REGISTRY_CREDENTIALS) {
            dockerImage.push()
          }
        }
      }
    }
    stage('Deploy to Cluster') {
      steps {
        script {
          sh '/var/lib/jenkins/bin/kubectl set image deployment/${DEPLOYMENT_NAME} ${CONTAINER_NAME}=${DOCKER_REGISTRY}/${APP_NAME}:${BUILD_NUMBER}'
        }
      }
    }
  }
}
