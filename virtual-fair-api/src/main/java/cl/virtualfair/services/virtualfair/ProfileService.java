package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.Profile;
import cl.virtualfair.repositories.IProfileRepository;

@Service
public class ProfileService {

	@Autowired
	private IProfileRepository iProfileRepository;
	
	public ProfileService() {
		
	}
	
	public List<Profile> findAll(){
		
		List<Profile> profiles = iProfileRepository.findAll();
		
		return profiles;
	}
	
	public Profile findById(long id) {
		
		Profile profile = iProfileRepository.findById(id);
		
		return profile;
	}
}
