package cl.virtualfair.services.other;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;

import org.springframework.stereotype.Service;

import com.amazonaws.auth.AWSCredentials;
import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.model.ObjectMetadata;
import com.amazonaws.services.s3.model.S3Object;
import com.amazonaws.util.Base64;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;

@Service
public class AmazonS3Service {
	
	private String accessKey = "AKIAIFXSNFVW3Q6X754Q";
	private String secretKey = "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";
	private String bucketName = "virtual-fair";
	
	private AmazonS3 amazonS3;
	
	public AmazonS3Service() {
		
		AWSCredentials awsCredentials = new BasicAWSCredentials(accessKey, secretKey);
		
		AWSStaticCredentialsProvider awsStaticCredentialsProvider = new AWSStaticCredentialsProvider(awsCredentials);
		
		amazonS3 = AmazonS3ClientBuilder.standard().withCredentials(awsStaticCredentialsProvider).withRegion(Regions.SA_EAST_1).build();
	}
	
	public S3Object getFile(String fileName) {
		
		S3Object s3Object = null;
		
		if(amazonS3.doesBucketExistV2(bucketName)) {
			
			if(amazonS3.doesObjectExist(bucketName, fileName)) {
			
				s3Object = amazonS3.getObject(bucketName, fileName);
			}
			
		}
		
		return s3Object;
	}
	
	public String getUrlFile(String fileName) {
		
		String url = null;
		
		if(amazonS3.doesBucketExistV2(bucketName)) {
			
			if(amazonS3.doesObjectExist(bucketName, fileName)) {
			
				S3Object s3Object = amazonS3.getObject(bucketName, fileName);
			
				//GeneratePresignedUrlRequest generatePresignedUrlRequest = new GeneratePresignedUrlRequest(s3Object.getBucketName(), s3Object.getKey()).withMethod(HttpMethod.GET);
				
				//url = amazonS3.generatePresignedUrl(generatePresignedUrlRequest).toString();
				
				url = "https://" + s3Object.getBucketName() + ".s3." + amazonS3.getRegionName() + ".amazonaws.com/" + s3Object.getKey();
			}
			
		}
		
		return url;
	}
	
	public Boolean uploadFile(String fileName, String fileBase64) throws IOException {
		
		Boolean result = false;
		
		if(amazonS3.doesBucketExistV2(bucketName)) {
			
			if(amazonS3.doesObjectExist(bucketName, fileName)) {
			
				deleteFile(fileName);
				
				byte[] bytes = Base64.decode(fileBase64);
				
				InputStream inputStream = new ByteArrayInputStream(bytes);
				
				amazonS3.putObject(bucketName, fileName, inputStream, new ObjectMetadata());
				
				inputStream.close();
				
				result = true;
				
			}else {

				byte[] bytes = Base64.decode(fileBase64);
				
				InputStream inputStream = new ByteArrayInputStream(bytes);
				
				amazonS3.putObject(bucketName, fileName, inputStream, new ObjectMetadata());
				
				result = true;
			}
			
		}
		
		return result;
		
	}
	
	public Boolean deleteFile(String fileName) {
		
		Boolean result = false;
		
		if(amazonS3.doesBucketExistV2(bucketName)) {
			
			if(amazonS3.doesObjectExist(bucketName, fileName)) {
				
				S3Object s3Object = amazonS3.getObject(bucketName, fileName);
				
				amazonS3.deleteObject(s3Object.getBucketName(), s3Object.getKey());
				
				result = true;
			}
			
		}
		
		return result;
		
	}
}
