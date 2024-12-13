using HenriksHobbyLager.Models;

public interface IDisplayService
{
    void DisplayProduct(Product product);
    void DisplayMessage(string message);
    void DrawTable(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8);
}