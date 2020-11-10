package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="PRODUCT")
@Proxy(lazy=false)
public class Product implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="PRODUCT_SEQ")
	@SequenceGenerator(name="PRODUCT_SEQ", sequenceName="PRODUCT_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;

	@Column(name="NAME")
	private String Name;
	
	@javax.persistence.Transient
	private String ImagePath;

	public Product() {
	}
	
	public Product(long id) {
		Id = id;
	}
	
	public Product(long id, String name, String imagePath) {
		Id = id;
		Name = name;
		ImagePath = imagePath;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public String getImagePath() {
		return ImagePath;
	}

	public void setImagePath(String imagePath) {
		ImagePath = imagePath;
	}
}
