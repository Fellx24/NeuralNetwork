using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public NeuronType NeuronType { get; }
        public int NeuronsCount => Neurons?.Count ?? 0;
        public Layer(List<Neuron> neurons, NeuronType neuronType = NeuronType.Hidden)
        {
            Neurons = neurons;
            NeuronType = neuronType;
        }

    }
}
