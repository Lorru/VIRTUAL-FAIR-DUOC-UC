package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;

import cl.virtualfair.models.virtualfair.TransportAuction;
import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;
import cl.virtualfair.repositories.ITransportAuctionRepository;
import org.springframework.stereotype.Service;

@Service
public class TransportAuctionService {

	@Autowired
	private ITransportAuctionRepository iTransportAuctionRepository;
	
	@Autowired
	private TransportAuctionCarrierService transportAuctionCarrierService;
	
	public TransportAuctionService() {
		
	}
	
	public List<TransportAuction> findAll(String searcher){
		
		List<TransportAuction> transportAuctions = new ArrayList<TransportAuction>();
		
		transportAuctions = iTransportAuctionRepository.findAll();
		
		return transportAuctions;
	}
	
	public List<TransportAuction> findByIdCarrier(long idCarrier){
		
		List<TransportAuction> transportAuctions = new ArrayList<TransportAuction>();
		
		List<TransportAuctionCarrier> transportAuctionCarriers = transportAuctionCarrierService.findByIdCarrier(idCarrier);
		
		List<Long> ids = transportAuctionCarriers.stream().map(TransportAuctionCarrier::getId).collect(Collectors.toList());
		
		transportAuctions = iTransportAuctionRepository.findByIds(ids);
		
		return transportAuctions;
	}
}
