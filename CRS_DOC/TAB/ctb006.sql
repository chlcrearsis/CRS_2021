/*--**********************************************
ARCHIVO:	ctb007.sql
TABLA:		Tabla de leyendas
AUTOR:		FVM-CREARSIS
FECHA:		05-07-2017
*/--**********************************************

CREATE TABLE ctb006(
	va_cod_ley		tinyint			NOT NULL,	-- Codigo leyenda de 0 A 99
	va_nom_ley		varchar(500)	NOT NULL,	-- Nombre de la leyenda
	
	CONSTRAINT pk1_ctb006 PRIMARY KEY(va_cod_ley)
) 

GO
	 INSERT ctb006 VALUES(1,  'Ley N� 453: Si se te ha vulnerado alg�n derecho puedes exigir la reposici�n o restauraci�n.') 
     INSERT ctb006 VALUES(2,  'Ley N� 453: El proveedor deber� dar cumplimiento a las condiciones ofertadas.') 
     INSERT ctb006 VALUES(3,  'Ley N� 453: Est�n prohibidas las pr�cticas comerciales abusivas, tienes derecho a denunciarlas.') 
     INSERT ctb006 VALUES(4,  'Ley N� 453: Tienes derecho a recibir informaci�n que te proteja de la publicidad enga�osa.') 
     INSERT ctb006 VALUES(5,  'Ley N� 453: Puedes acceder a la reclamaci�n cuando tus derechos han sido vulnerados.')
     INSERT ctb006 VALUES(6,  'Ley N� 453: Los contratos de adhesi�n deben redactarse en t�rminos claros, comprensibles, ' + 
     'legibles y deben informar todas las facilidades y limitaciones.')
     INSERT ctb006 VALUES(7,  'Ley N� 453: Se debe promover el consumo solidario,justo, en armon�a con la Madre Tierra y ' + 
     'precautelando el h�bitat, en el marco del Vivir Bien.')
     INSERT ctb006 VALUES(8,  'Ley N� 453: El proveedor de productos debe habilitar medios e instrumentos para efectuar ' + 
     'consultas y reclamaciones.')
     INSERT ctb006 VALUES(9,  'Ley N� 453: El proveedor debe brindar atenci�n sin discriminaci�n, con respeto, calidez ' + 
     'y cordialidad a los usuarios y consumidores.')
     INSERT ctb006 VALUES(10,  'Ley N� 453: Los servicios deben suministrarse en condiciones de inocuidad, calidad y seguridad.')
     INSERT ctb006 VALUES(11,  'Ley N� 453: Tienes derecho a un trato equitativo sin discriminaci�n en la oferta de servicios.')
     INSERT ctb006 VALUES(12,  'Ley N� 453: El proveedor deber� suministrar  el servicio en las modalidades y t�rminos ' + 
     'ofertados o convenidos.')
     INSERT ctb006 VALUES(13,  'Ley N� 453: En caso de incumplimiento a lo ofertado o convenido, el proveedor debe reparar ' + 
     'o sustituir el servicio.')
     INSERT ctb006 VALUES(14,  'Ley N� 453: Tienes derecho a recibir informaci�n sobre las caracter�sticas y contenidos ' + 
     'de los servicios que utilices.')
     INSERT ctb006 VALUES(15,  'Ley N� 453: La interrupci�n del servicio debe comunicarse con anterioridad a las ' + 
     'Autoridades que correspondan y a los usuarios afectados.')
     INSERT ctb006 VALUES(16,  'Ley N� 453: El proveedor de servicios debe habilitar medios e instrumentos para efectuar ' + 
     'consultas y reclamaciones.')
     INSERT ctb006 VALUES(17,  'Ley N� 453: El proveedor debe exhibir certificaciones de habilitaci�n o documentos que ' + 
     'acrediten las capacidades u ofertas de servicios especializados.')
     INSERT ctb006 VALUES(18,  'Ley N� 453: Los productos deben suministrarse en condiciones de inocuidad, calidad ' + 
     'y seguridad.')
     INSERT ctb006 VALUES(19,  'Ley N� 453: Est� prohibido importar, distribuir o comercializar productos expirados ' + 
     'o prontos a expirar.')
     INSERT ctb006 VALUES(20,  'Ley N� 453: Est� prohibido importar, distribuir o comercializar productos prohibidos o ' +
     'retirados en el pa�s de origen por atentar a la integridad f�sica y a la salud.')
     INSERT ctb006 VALUES(21,  'Ley N� 453: Tienes derecho a recibir informaci�n sobre las caracter�sticas y ' + 
     'contenidos de los productos que consumes.')
     INSERT ctb006 VALUES(22,  'Ley N� 453: Tienes derecho a un trato equitativo sin discriminaci�n en la oferta ' + 
     'de productos.')
     INSERT ctb006 VALUES(23,  'Ley N� 453: El proveedor deber� entregar el producto en las modalidades y t�rminos ' + 
     'ofertados o convenidos.')
     INSERT ctb006 VALUES(24,  'Ley N� 453: En caso de incumplimiento a lo ofertado o convenido, el proveedor debe ' + 
     'reparar o sustituir el producto.')
     INSERT ctb006 VALUES(25,  'Ley N� 453: Los alimentos declarados de primera necesidad deben ser suministrados de ' + 
     'manera adecuada, oportuna, continua y a precio justo.')
     INSERT ctb006 VALUES(26,  'Ley N� 453: El prestador de servicio m�dico debe brindar atenci�n de calidad al paciente.')
     INSERT ctb006 VALUES(27,  'Ley N� 453: Cuando lo solicite el paciente, se debe informar los resultados de ex�menes, ' + 
     'diagn�sticos y estudios de laboratorio.')
     INSERT ctb006 VALUES(28,  'Ley N� 453: El prestador de servicio m�dico debe prescribir medicamentos debidamente ' + 
     'autorizados por el Ministerio de Salud.')
     INSERT ctb006 VALUES(29,  'Ley N� 453: Se debe otorgar el auxilio y atenci�n necesarios en casos de urgencia o ' + 
     'emergencia hospitalaria, sin aducir excusa alguna.')
     INSERT ctb006 VALUES(30,  'Ley N� 453: Se debe brindar alternativas de pago por servicios utilizados en emergencia ' + 
     'm�dica u hospitalaria, no pudiendo retenerse al usuario por deuda.')
     INSERT ctb006 VALUES(31,  'Ley N� 453: Tienes derecho a denunciar la existencia de productos y servicios que pongan ' + 
     'en riesgo tu salud o integridad f�sica.')
     INSERT ctb006 VALUES(32,  'Ley N� 453: La entidad financiera tiene la obligaci�n de promover la educaci�n ' + 
     'financiera.')
     INSERT ctb006 VALUES(33,  'Ley N� 453: La entidad financiera debe facilitar en cualquier momento y gratuitamente, ' + 
     'toda la informaci�n de los movimientos bancarios, financieros o de cr�dito.')
     INSERT ctb006 VALUES(34,  'Ley N� 453: La entidad financiera debe informar por escrito los motivos por los cuales ' + 
     'se deneg� un cr�dito.')
     INSERT ctb006 VALUES(35, 'Ley N� 453: Los medios de comunicaci�n deben difundir mensajes o programas de ' + 
     'educaci�n de consumo responsable y sustentable.')
     INSERT ctb006 VALUES(36, 'Ley N� 453: Los medios de comunicaci�n deben promover el respeto de los derechos de ' + 
     'los usuarios y consumidores.')
     INSERT ctb006 VALUES(37, 'Ley N� 453: Las publicaciones, mensajes e im�genes no deben promover la sumisi�n o ' + 
     'explotaci�n de las mujeres.')
     INSERT ctb006 VALUES(38, 'Ley N� 453: Las publicaciones, mensajes e im�genes no deben deshonrar y atentar ' + 
     'contra la dignidad e imagen de la mujer.')
     INSERT ctb006 VALUES(39, 'Ley N� 453: Los medios de comunicaci�n deben evitar contenidos inapropiados que ' + 
     'vulneren la protecci�n de ni�as, ni�os y adolescentes.')
GO