#!/bin/bash

# Navigate to the project directory
cd "$(dirname "$0")/../src/UserManagementService"

# Build the project
dotnet build

# Publish the project
dotnet publish -c Release -o ../publish

# Navigate to the infrastructure directory
cd ../../infrastructure/cloudformation

# Deploy the AuroraDB and S3 bucket using CloudFormation
aws cloudformation deploy --template-file aurora-db.yaml --stack-name UserManagementDBStack --capabilities CAPABILITY_IAM
aws cloudformation deploy --template-file s3-bucket.yaml --stack-name UserProfilePictureBucketStack --capabilities CAPABILITY_IAM

# Navigate back to the publish directory
cd ../../scripts/../publish

# Deploy the application to AWS (this could be an Elastic Beanstalk, ECS, etc.)
# Example for Elastic Beanstalk:
# eb deploy UserManagementService

echo "Deployment completed successfully."