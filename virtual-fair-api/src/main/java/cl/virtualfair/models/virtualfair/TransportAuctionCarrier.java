package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="TRANSPORT_AUCTION_CARRIER")
@Proxy(lazy=false)
public class TransportAuctionCarrier implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="TRANSPORT_AUCTION_CARRIER_SEQ")
	@SequenceGenerator(name="TRANSPORT_AUCTION_CARRIER_SEQ", sequenceName="TRANSPORT_AUCTION_CARRIER_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;
	
	@Column(name="ID_TRANSPORT_AUCTION")
	private long IdTransportAuction;
	
	@Column(name="ID_CARRIER")
	private long IdCarrier;
	
	@Column(name="PRICE")
	private long Price;
	
    @JoinColumn(name="ID_TRANSPORT_AUCTION", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private TransportAuction TransportAuction;
    
    @JoinColumn(name="ID_CARRIER", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User Carrier;

	public TransportAuctionCarrier() {
	}    
    
	public TransportAuctionCarrier(long id) {
		Id = id;
	}

	public TransportAuctionCarrier(long id, long idTransportAuction, long idCarrier, long price,
			cl.virtualfair.models.virtualfair.TransportAuction transportAuction, User carrier) {
		Id = id;
		IdTransportAuction = idTransportAuction;
		IdCarrier = idCarrier;
		Price = price;
		TransportAuction = transportAuction;
		Carrier = carrier;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdTransportAuction() {
		return IdTransportAuction;
	}

	public void setIdTransportAuction(long idTransportAuction) {
		IdTransportAuction = idTransportAuction;
	}

	public long getIdCarrier() {
		return IdCarrier;
	}

	public void setIdCarrier(long idCarrier) {
		IdCarrier = idCarrier;
	}

	public long getPrice() {
		return Price;
	}

	public void setPrice(long price) {
		Price = price;
	}

	public TransportAuction getTransportAuction() {
		return TransportAuction;
	}

	public void setTransportAuction(TransportAuction transportAuction) {
		TransportAuction = transportAuction;
	}

	public User getCarrier() {
		return Carrier;
	}

	public void setCarrier(User carrier) {
		Carrier = carrier;
	}
}
