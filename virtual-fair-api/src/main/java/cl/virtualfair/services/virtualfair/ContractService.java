package cl.virtualfair.services.virtualfair;

import java.lang.reflect.Field;
import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.Contract;
import cl.virtualfair.repositories.IContractRepository;

@Service
public class ContractService {

	@Autowired
	private IContractRepository iContractRepository;
	
	public ContractService() {
		
	}
	
	public List<Contract> findAll(){
		
		List<Contract> contracts = iContractRepository.findAll();
		
		return contracts;
		
	}
	
	public Contract findByIdUser(long idUser){
		
		Contract contract = iContractRepository.findByIdUser(idUser);
		
		return contract;
	}
	
	public Contract findById(long id){
		
		Contract contract = iContractRepository.findById(id);
		
		return contract;
	}
	
	public Contract create(Contract contract) {
		
		contract.setCreationDate(LocalDateTime.now());
		
		contract = iContractRepository.save(contract);
		
		return contract;
	}
	
	public Contract updateById(Contract contract) throws IllegalArgumentException, IllegalAccessException, NoSuchFieldException, SecurityException  {
		
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
		
		contractExisting = iContractRepository.save(contractExisting);
		
		return contractExisting;
	}
	
	public Contract destroyById(long id) {
		
		Contract contract = findById(id);
		
		iContractRepository.delete(contract);
		
		contract = findById(id);
		
		return contract;
	}
}
