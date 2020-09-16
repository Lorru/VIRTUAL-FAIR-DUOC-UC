package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;
import cl.virtualfair.repositories.ITransportAuctionCarrierRepository;

@Service
public class TransportAuctionCarrierService {

	@Autowired
	private ITransportAuctionCarrierRepository iTransportAuctionCarrierRepository;
	
	public TransportAuctionCarrierService() {
		
	}
	
	public List<TransportAuctionCarrier> findByIdCarrier(long idCarrier){
		
		List<TransportAuctionCarrier> transportAuctionCarriers = iTransportAuctionCarrierRepository.findByIdCarrier(idCarrier);
		
		return transportAuctionCarriers;
		
	}
}
