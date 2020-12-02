package cl.virtualfair.services.virtualfair;

import java.io.IOException;
import java.lang.reflect.Field;
import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.Contract;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.repositories.IContractRepository;
import cl.virtualfair.services.other.AmazonS3Service;

@Service
public class ContractService {

	@Autowired
	private IContractRepository iContractRepository;
	
	@Autowired
	private AmazonS3Service amazonS3Service;
	
	@Autowired
	private UserService userService;
	
	public ContractService() {
		
	}
	
	public List<Contract> findAll(){
		
		List<Contract> contracts = iContractRepository.findAll();
		
		return contracts;
		
	}
	
	public List<Contract> findByIdUser(long idUser){
		
		List<Contract> contracts = iContractRepository.findByIdUser(idUser);
		
		return contracts;
	}
	
	public Contract findByIdUserAndIsValidEqualToOne(long idUser){
		
		Contract contract = iContractRepository.findByIdUserAndIsValidEqualToOne(idUser);
		
		return contract;
	}
	
	public Contract findById(long id){
		
		Contract contract = iContractRepository.findById(id);
		
		if(contract != null) {
			
			String fileName = amazonS3Service.getUrlFile("contracts/" + contract.getUser().getFullName().toLowerCase().replace(' ', '_') + "_" + contract.getId());
			
			contract.setContractPath(fileName);
		}
		
		return contract;
	}
	
	public Contract create(Contract contract) throws IOException {
		
		contract.setCreationDate(LocalDateTime.now());
		
		LocalDateTime dateNow = LocalDateTime.now();
		
		if(contract.getExpirationDate().compareTo(dateNow) < 0) {
			
			contract.setIsValid(0);
			
		}else {
			
			contract.setIsValid(1);
			
		}
		
		List<Contract> contracts = findByIdUser(contract.getIdUser());
		
		if(contracts.size() > 0) {
			
			for (Contract contractExisting : contracts) {
				
				contractExisting.setIsValid(0);
				
				iContractRepository.save(contractExisting);
				
			}
			
		}
		
		
		contract = iContractRepository.save(contract);
		
		if(contract != null && contract.getId() != 0 && contract.getContractPath() != null && !contract.getContractPath().isEmpty()) {
			
			User user = userService.findById(contract.getIdUser());
			
			if(user != null) {
			
				String fileBase64 = contract.getContractPath().split(",")[1];
				String dataType = "." + contract.getContractPath().split("/")[1].split(";")[0];
				
				amazonS3Service.uploadFile("contracts/" + user.getFullName().toLowerCase().replace(' ', '_') + "_" + contract.getId() + dataType, fileBase64);
				
			}
			
		}
		
		return contract;
	}
	
	public Contract updateById(Contract contract) throws IllegalArgumentException, IllegalAccessException, NoSuchFieldException, SecurityException, IOException  {
		
		Contract contractExisting = findById(contract.getId());
		
		List<Field> fields = Arrays.stream(contractExisting.getClass().getDeclaredFields()).filter(x -> 
		x.getName() != "serialVersionUID" && 
		x.getName() != "Id"
		).collect(Collectors.toList());

		for (Field field : fields) {
		
			Field fieldObject = contract.getClass().getDeclaredField(field.getName());
			
			fieldObject.setAccessible(true);
			field.setAccessible(true);
			
			field.set(contractExisting, fieldObject.get(contract));
		}
		
		if(contract.getContractPath() != null && !contract.getContractPath().isEmpty()) {
			
			User user = userService.findById(contract.getIdUser());
			
			if(user != null) {
			
				String fileBase64 = contract.getContractPath().split(",")[1];
				String dataType = "." + contract.getContractPath().split("/")[1].split(";")[0];
				
				amazonS3Service.uploadFile("contracts/" + user.getFullName().toLowerCase().replace(' ', '_') + "_" + contract.getId() + dataType, fileBase64);
				
			}
			
		}
		
		LocalDateTime dateNow = LocalDateTime.now();
		
		if(contractExisting.getExpirationDate().compareTo(dateNow) < 0) {
			
			contractExisting.setIsValid(0);
			
		}else {
			
			contractExisting.setIsValid(1);
			
		}
		
		contractExisting = iContractRepository.save(contractExisting);
		
		return contractExisting;
	}
	
	public Contract destroyById(long id) {
		
		Contract contract = findById(id);
		
		User user = userService.findById(contract.getIdUser());
		
		if(user != null) {
			
			amazonS3Service.deleteFile("contracts/" + user.getFullName().toLowerCase().replace(' ', '_') + "_" + contract.getId());
			
		}
		
		iContractRepository.delete(contract);
		
		contract = findById(id);
		
		return contract;
	}
}
