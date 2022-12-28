using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortComparison.SortingAlgorithms
{
    public class HeapSort : SortAlgorithm
    {
        public override string Name => "HeapSort";

        public override void Sort(IList<int> arrayToSort)
        {
            // Baue den Heap auf
            for (int i = arrayToSort.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(arrayToSort, arrayToSort.Count, i);
            }

            // Extrahiere elemente eins nach dem anderen vom heap
            for (int i = arrayToSort.Count - 1; i >= 0; i--)
            {
                // Verschiebe den Root ans ende
                int temp = arrayToSort[0];
                arrayToSort[0] = arrayToSort[i];
                arrayToSort[i] = temp;

                Heapify(arrayToSort, i, 0);
            }
        }

        private void Heapify(IList<int> array, int heapSize, int rootIndex)
        {
            int grössteZahl = rootIndex;
            int leftChildIndex = 2 * rootIndex + 1;
            int rightChildIndex = 2 * rootIndex + 2;

            // Kontrolliere ob linkes "child" grösser ist als der root
            if (leftChildIndex < heapSize && array[leftChildIndex] > array[grössteZahl])
            {
                grössteZahl = leftChildIndex;
            }

            // Kontrolliere ob rechtes "child" grösser ist als das grösste bis dato
            if (rightChildIndex < heapSize && array[rightChildIndex] > array[grössteZahl])
            {
                grössteZahl = rightChildIndex;
            }

            // falls das grösste nicht der root ist, swape und führe den heapify weiter aus.
            if (grössteZahl != rootIndex)
            {
                int temp = array[rootIndex];
                array[rootIndex] = array[grössteZahl];
                array[grössteZahl] = temp;
                Heapify(array, heapSize, grössteZahl);
            }
        }
    }
}
