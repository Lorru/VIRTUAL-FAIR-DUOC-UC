package cl.virtualfair.services.other;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

import org.springframework.stereotype.Service;

import com.amazonaws.auth.AWSCredentials;
import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.ListObjectsV2Result;
import com.amazonaws.services.s3.model.ObjectMetadata;
import com.amazonaws.services.s3.model.PutObjectRequest;
import com.amazonaws.services.s3.model.S3Object;
import com.amazonaws.services.s3.model.S3ObjectSummary;
import com.amazonaws.util.Base64;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;

@Service
public class AmazonS3Service {
	
	private String accessKey = "AKIAJOZJATDKZH7NQUBA";
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
			
			ListObjectsV2Result listObjectsV2Result =  amazonS3.listObjectsV2(bucketName);
			
			List<S3ObjectSummary> s3ObjectSummaries = listObjectsV2Result.getObjectSummaries();
			
			if(s3ObjectSummaries.stream().filter(x -> x.getKey().toLowerCase().contains(fileName.toLowerCase())).count() > 0) {
				
				S3ObjectSummary s3ObjectSummary = s3ObjectSummaries.stream().filter(x -> x.getKey().toLowerCase().contains(fileName.toLowerCase())).findFirst().get();
			
				s3Object = amazonS3.getObject(bucketName, s3ObjectSummary.getKey());
				
			}
			
		}
		
		return s3Object;
	}
	
	public String getUrlFile(String fileName) {
		
		String url = null;
		
		if(amazonS3.doesBucketExistV2(bucketName)) {
			
			ListObjectsV2Result listObjectsV2Result =  amazonS3.listObjectsV2(bucketName);
			
			List<S3ObjectSummary> s3ObjectSummaries = listObjectsV2Result.getObjectSummaries();
			
			if(s3ObjectSummaries.stream().filter(x -> x.getKey().toLowerCase().contains(fileName.toLowerCase())).count() > 0) {
				
				S3ObjectSummary s3ObjectSummary = s3ObjectSummaries.stream().filter(x -> x.getKey().toLowerCase().contains(fileName.toLowerCase())).findFirst().get();
			
				S3Object s3Object = amazonS3.getObject(bucketName, s3ObjectSummary.getKey());
				
				if(s3Object != null) {
				
					//GeneratePresignedUrlRequest generatePresignedUrlRequest = new GeneratePresignedUrlRequest(s3Object.getBucketName(), s3Object.getKey()).withMethod(HttpMethod.GET);
					
					//url = amazonS3.generatePresignedUrl(generatePresignedUrlRequest).toString();
					
					url = "https://" + s3Object.getBucketName() + ".s3." + amazonS3.getRegionName() + ".amazonaws.com/" + s3Object.getKey();
					
				}
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
				
				amazonS3.putObject(new PutObjectRequest(bucketName, fileName, inputStream, new ObjectMetadata()).withCannedAcl(CannedAccessControlList.PublicRead));
				
				inputStream.close();
				
				result = true;
				
			}else {

				byte[] bytes = Base64.decode(fileBase64);
				
				InputStream inputStream = new ByteArrayInputStream(bytes);
				
				amazonS3.putObject(new PutObjectRequest(bucketName, fileName, inputStream, new ObjectMetadata()).withCannedAcl(CannedAccessControlList.PublicRead));
				
				result = true;
			}
			
		}
		
		return result;
		
	}
	
	public Boolean deleteFile(String fileName) {
		
		Boolean result = false;
		
		if(amazonS3.doesBucketExistV2(bucketName)) {
			
			ListObjectsV2Result listObjectsV2Result =  amazonS3.listObjectsV2(bucketName);
			
			List<S3ObjectSummary> s3ObjectSummaries = listObjectsV2Result.getObjectSummaries();
			
			if(s3ObjectSummaries.stream().filter(x -> x.getKey().toLowerCase().contains(fileName.toLowerCase())).count() > 0) {
				
				S3ObjectSummary s3ObjectSummary = s3ObjectSummaries.stream().filter(x -> x.getKey().toLowerCase().contains(fileName.toLowerCase())).findFirst().get();
				
				S3Object s3Object = amazonS3.getObject(bucketName, s3ObjectSummary.getKey());
				
				amazonS3.deleteObject(s3Object.getBucketName(), s3Object.getKey());
				
				result = true;
				
			}
			
		}
		
		return result;
		
	}
}
