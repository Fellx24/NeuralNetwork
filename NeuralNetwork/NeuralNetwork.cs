using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public List<Layer> Layers { get; }
        public Topology Topology { get; }
        public NeuralNetwork(Topology topology)
        {
            Topology = topology;
            Layers = new List<Layer>();
            CreateInputLayer();
            CreateHiddenLayers();
            CreateInputLayer();
        }
        private void CreateInputLayer()
        {
            List<Neuron> inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                Neuron neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }
            Layer inputLayer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }
        private void CreateOutputLayer()
        {
            List<Neuron> outputNeurons = new List<Neuron>();
            Layer lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                Neuron neuron = new Neuron(lastLayer.NeuronsCount, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            Layer outputLayer = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayer);
        }
        private void CreateHiddenLayers()
        {
            for (int i = 0; i < Topology.HiddenLayers.Count; i++)
            {
                List<Neuron> hiddenNeuron = new List<Neuron>();
                Layer lastLayer = Layers.Last();
                for (int j = 0; j < Topology.HiddenLayers[i]; j++)
                {
                    Neuron neuron = new Neuron(lastLayer.NeuronsCount);
                    hiddenNeuron.Add(neuron);
                }
                Layer hiddenLayer = new Layer(hiddenNeuron);
                Layers.Add(hiddenLayer);
            }
        }

          
    }
}
