using System;
using System.Collections.Generic;
// DAST Antoine 
public class Program
{
	public struct Livre
	{
		public string titre;
		public string auteur;
		public int annee;
		public int pages;
		public bool estDisponible;
	}
	
	public static void Main()
	{
		Livre l1;
		l1.titre = "La femme de ménage";
		l1.auteur = "Walter Brown";
		l1.annee = 2026;
		l1.pages = 267;
		l1.estDisponible = false;
		
		Livre l2;
		l2.titre = "Nautilus";
		l2.auteur = "Carrie Sully";
		l2.annee = 2012;
		l2.pages = 354;
		l2.estDisponible = true;
		
		Livre l3;
		l3.titre = "Dahna";
		l3.auteur = "Rom1";
		l3.annee = 1954;
		l3.pages = 548;
		l3.estDisponible = false;
		
		List<Livre> Livres = new List<Livre>();
		Livres.Add(l1);
		Livres.Add(l2);
		Livres.Add(l3);
		
		int choix = 0;
		while (choix != 5)
		{
			Console.WriteLine("\n=== MENU ===");
			Console.WriteLine("1 - Afficher tous les livres");
			Console.WriteLine("2 - Afficher les livres disponibles");
			Console.WriteLine("3 - Rechercher un livre");
			Console.WriteLine("4 - Emprunter un livre");
			Console.WriteLine("5 - Quitter");
			Console.Write("Votre choix : ");
			
			int.TryParse(Console.ReadLine(), out choix);
			
			switch (choix)
			{
				case 1:
					foreach (Livre l in Livres)
						afficherLivre(l);
					break;
				case 2:
					foreach (Livre l in Livres)
						if (l.estDisponible == true)
							afficherLivre(l);
					break;
				case 3:
					recherche(Livres);
					break;
				case 4:
					emprunt(Livres);
					break;
				case 5:
					Console.WriteLine("Au revoir !");
					break;
				default:
					Console.WriteLine("Choix invalide.");
					break;
			}
		}
	}

	static void afficherLivre(Livre l)
	{
		Console.WriteLine($"Titre : {l.titre}");
		Console.WriteLine($"Auteur : {l.auteur}");
		Console.WriteLine($"Année : {l.annee}");
		Console.WriteLine($"Pages : {l.pages}");
		Console.WriteLine($"Disponibilité : {l.estDisponible}\n");
	}

	static void sommePages(List<Livre> livres)
	{
		int somme = 0;
		foreach (Livre l in livres)
			somme += l.pages;
		Console.WriteLine($"Il y a {somme} pages.");
	}

	static void sommeLivres(List<Livre> livres)
	{
		int somme = 0;
		foreach (Livre l in livres)
			if (l.estDisponible == true)
				somme += 1;
		Console.WriteLine($"Il y a {somme} livre(s) disponible(s).");
	}

	static void recherche(List<Livre> livres)
	{
		Console.WriteLine("Le titre ?");
		string titreRecherche = Console.ReadLine();
		bool trouve = false;
		foreach (Livre l in livres)
		{
			if (titreRecherche == l.titre)
			{
				afficherLivre(l);
				trouve = true;
			}
		}
		if (trouve == false)
			Console.WriteLine("Livre introuvable");
	}

	static void emprunt(List<Livre> livres)
	{
		Console.WriteLine("Le titre ?");
		string titreRecherche = Console.ReadLine();
		bool possible = false;
		for (int i = 0; i < livres.Count; i++)
		{
			if (titreRecherche == livres[i].titre)
			{
				afficherLivre(livres[i]);
				if (livres[i].estDisponible == true)
				{
					possible = true;
					Livre copie = livres[i];
					copie.estDisponible = false;
					livres[i] = copie;
					Console.WriteLine("Emprunt validé");
				}
			}
		}
		if (possible == false)
			Console.WriteLine("Emprunt impossible");
	}
}
