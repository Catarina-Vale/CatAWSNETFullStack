# AWS User Management Infrastructure

This directory contains the infrastructure setup for the AWS User Management microservice. It includes CloudFormation templates for provisioning the necessary resources in AWS.

## CloudFormation Templates

- **aurora-db.yaml**: This template sets up an Amazon Aurora database instance for user data storage. It defines the database cluster, instance, and necessary configurations.

- **s3-bucket.yaml**: This template creates an Amazon S3 bucket for storing user profile pictures. It includes configurations for bucket policies and permissions.

## Deployment

To deploy the infrastructure, use the provided scripts in the `scripts` directory. Ensure that you have the AWS CLI configured with the necessary permissions to create the resources defined in the CloudFormation templates.

## Usage

After deploying the infrastructure, you can start the User Management Service, which will interact with the AuroraDB and S3 bucket as defined in the service architecture.