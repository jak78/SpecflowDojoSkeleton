Fonctionnalité: Développer une story

Contexte: Composition du projet et de l'équipe
	Soit le projet 'Crocto' avec les stories suivantes
	| Titre                | Charge |
	| Souscrire un contrat | 2      |
	| Déclarer un sinistre | 10     |
	| Résilier un contrat  | 1      |

	Soit l'équipe 'A-team' est constituée de 
	| Nom   |
	| Alice |
	| Bob   |

	Et l'équipe 'A-team' travaille sur le projet 'Crocto'

Scénario: Quand un développeur travaille sur une story, la charge de travail restante sur la story diminue

	Etant donné le daily pour le projet 'Crocto'
	Et que 'Alice' travaille sur 'Souscrire un contrat'
	Et que 'Bob' travaille sur 'Déclarer un sinistre'
	Quand la journée se termine
	Alors les stories du projet 'Crocto' sont dans l'état suivant
	| Titre                | Charge |
	| Souscrire un contrat | 1      |
	| Déclarer un sinistre | 9      |
	| Résilier un contrat  | 1      |

Scénario: Une story est terminée lorsque sa charge atteint 0

	Etant donné le daily pour le projet 'Crocto'
	Et que 'Alice' travaille sur 'Résilier un contrat'
	Quand la journée se termine
	Alors les stories du projet 'Crocto' sont dans l'état suivant
	| Titre                | Charge |
	| Souscrire un contrat | 2      |
	| Déclarer un sinistre | 10     |
