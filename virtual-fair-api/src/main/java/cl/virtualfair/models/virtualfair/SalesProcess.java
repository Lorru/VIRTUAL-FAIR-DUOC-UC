package cl.virtualfair.models.virtualfair;

import java.io.Serializable;
import java.time.LocalDateTime;

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
@Table(name="SALES_PROCESS")
@Proxy(lazy=false)
public class SalesProcess implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="SALES_PROCESS_SEQ")
	@SequenceGenerator(name="SALES_PROCESS_SEQ", sequenceName="SALES_PROCESS_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;
	
	@Column(name="ID_PURCHASE_REQUEST")
	private long IdPurchaseRequest;
	
	@Column(name="ID_SALES_PROCESS_STATUS")
	private long IdSalesProcessStatus;
	
	@Column(name="CREATION_DATE")
	private LocalDateTime CreationDate;
	
	@Column(name="UPDATE_DATE")
	private LocalDateTime UpdateDate;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequest PurchaseRequest;
    
    @JoinColumn(name="ID_SALES_PROCESS_STATUS", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private SalesProcessStatus SalesProcessStatus;

	public SalesProcess() {
	}    
    
	public SalesProcess(long id) {
		Id = id;
	}

	public SalesProcess(long id, long idPurchaseRequest, long idSalesProcessStatus, LocalDateTime creationDate,
			LocalDateTime updateDate, cl.virtualfair.models.virtualfair.PurchaseRequest purchaseRequest,
			cl.virtualfair.models.virtualfair.SalesProcessStatus salesProcessStatus) {
		Id = id;
		IdPurchaseRequest = idPurchaseRequest;
		IdSalesProcessStatus = idSalesProcessStatus;
		CreationDate = creationDate;
		UpdateDate = updateDate;
		PurchaseRequest = purchaseRequest;
		SalesProcessStatus = salesProcessStatus;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdPurchaseRequest() {
		return IdPurchaseRequest;
	}

	public void setIdPurchaseRequest(long idPurchaseRequest) {
		IdPurchaseRequest = idPurchaseRequest;
	}

	public long getIdSalesProcessStatus() {
		return IdSalesProcessStatus;
	}

	public void setIdSalesProcessStatus(long idSalesProcessStatus) {
		IdSalesProcessStatus = idSalesProcessStatus;
	}

	public LocalDateTime getCreationDate() {
		return CreationDate;
	}

	public void setCreationDate(LocalDateTime creationDate) {
		CreationDate = creationDate;
	}

	public LocalDateTime getUpdateDate() {
		return UpdateDate;
	}

	public void setUpdateDate(LocalDateTime updateDate) {
		UpdateDate = updateDate;
	}

	public PurchaseRequest getPurchaseRequest() {
		return PurchaseRequest;
	}

	public void setPurchaseRequest(PurchaseRequest purchaseRequest) {
		PurchaseRequest = purchaseRequest;
	}

	public SalesProcessStatus getSalesProcessStatus() {
		return SalesProcessStatus;
	}

	public void setSalesProcessStatus(SalesProcessStatus salesProcessStatus) {
		SalesProcessStatus = salesProcessStatus;
	}
}
