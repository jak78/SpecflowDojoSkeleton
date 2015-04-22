Fonctionnalité: Fin de partie

Scénario: La partie est gagnée si il n'y a plus de story avant la date de release

	Etant donné le projet 'Crocto' démarrant le '17/08/2014', release prévue le '17/08/2015' et avec les stories suivantes
	| Titre                | Charge |
	| Souscrire un contrat | 1      |

	Etant donnée l'équipe 'A-Team' est constituée de 
	| Nom   |
	| Alice |
	Et l'équipe 'A-Team' travaille sur le projet 'Crocto'
	
	Etant donné le daily pour le projet 'Crocto'
	Et que 'Alice' travaille sur 'Souscrire un contrat'
	
	Quand la journée se termine
	Alors le projet est terminé à temps


Scénario: La partie est perdue si il reste de la charge après la date de release

	Etant donné le projet 'Crocto' démarrant le '16/08/2014', release prévue le '17/08/2014' et avec les stories suivantes
	| Titre                | Charge |
	| Souscrire un contrat |     2  |

	Et l'équipe 'A-Team' est constituée de 
	| Nom   |
	| Alice |

	Et l'équipe 'A-Team' travaille sur le projet 'Crocto'
	
	Etant donné le daily pour le projet 'Crocto'
	Et que 'Alice' travaille sur 'Souscrire un contrat'
	
	Quand la journée se termine
	Alors le projet est en retard

